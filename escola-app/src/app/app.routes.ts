import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DisciplineComponent } from './features/discipline/discipline.component';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  //{ path: '', component: AppComponent },
  { path: 'discipline', component: DisciplineComponent },
  {
    path: 'discipline',
    loadChildren: () =>
      import('./features/discipline/discipline.routes').then(
        (m) => m.routes
      ), // Lazy loading da rota de discipline
  },
];
