import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Disciplina } from '../models/disciplina.model';

@Injectable({
  providedIn: 'root'
})
export class DisciplinaService {

  private readonly API_URL = environment.apiUrl + '/disciplina';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Disciplina[]> {
    return this.http.get<Disciplina[]>(this.API_URL);
  }

  getById(id: number): Observable<Disciplina> {
    return this.http.get<Disciplina>(`${this.API_URL}/${id}`);
  }

  create(disciplina: Disciplina): Observable<Disciplina> {
    return this.http.post<Disciplina>(this.API_URL, disciplina);
  }

  update(id: number, disciplina: Disciplina): Observable<Disciplina> {
    return this.http.put<Disciplina>(`${this.API_URL}/${id}`, disciplina);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
}
