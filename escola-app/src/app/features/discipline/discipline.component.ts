import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HeaderTitleService } from '../../core/services/header-title.service';
import { CommonModule } from '@angular/common';
import { Disciplina } from './models/disciplina.model';
import { DisciplinaService } from './services/disciplina.service';
import {MatTableModule, MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';

@Component({
  selector: 'app-discipline',
  imports: [RouterModule, CommonModule, MatTableModule, MatPaginatorModule],
  standalone: true,
  templateUrl: './discipline.component.html',
  styleUrl: './discipline.component.css',
})
export class DisciplineComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['codDisc', 'qtdCred', 'nomDisc', 'codDiscEquiv'];
  disciplinas: Disciplina[] = [];
  data = new MatTableDataSource<any>([]);;


  constructor(
    private headerTitleService: HeaderTitleService,
    private disciplinaService: DisciplinaService
  ) {}

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.data.paginator = this.paginator;
  }
  ngOnInit(): void {
    this.headerTitleService.setTitle('Disciplinas');
    this.getAll();
  }

  private getAll(): void {
    this.disciplinas = [];
    this.disciplinaService.getAll().subscribe(
      (response: any) => {
        //console.log(response);
        if (response && Array.isArray(response.disciplinas)) {
          //this.disciplinas = response.disciplinas;
          this.data = new MatTableDataSource<Disciplina>(response.disciplinas);
          //console.log(this.disciplinas);
        } else {
          console.error('O retorno não contém um array de categorias.');
        }
      },
      (error: any) => {
        console.log(error);
      } 
    );
  }
}
