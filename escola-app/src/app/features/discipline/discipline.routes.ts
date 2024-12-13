import { Routes } from '@angular/router';
import { DisciplineComponent } from './discipline.component';
import { DisciplineListComponent } from './components/discipline-list/discipline-list.component';
import { DisciplineFormComponent } from './components/discipline-form/discipline-form.component';

export const routes: Routes = [
  { path: '', component: DisciplineComponent },
  { path: 'new', component: DisciplineFormComponent }
];