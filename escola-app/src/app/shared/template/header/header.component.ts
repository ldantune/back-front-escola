import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HeaderTitleService } from '../../../core/services/header-title.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  titulo: string = '';

  constructor(
    private headerTitleService: HeaderTitleService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.headerTitleService.title$.subscribe((title) => {
      this.titulo = title;
      this.cdr.detectChanges();
    });
  }
}