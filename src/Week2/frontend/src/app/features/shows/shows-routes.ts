import { Routes } from '@angular/router';
import { Shows } from './shows';
export const showsRoutes: Routes = [
  {
    path: '',
    component: Shows,
    children: [],
  },
];
