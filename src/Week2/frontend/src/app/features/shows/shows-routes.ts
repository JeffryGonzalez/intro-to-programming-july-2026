import { Routes } from '@angular/router';
import { Shows } from './shows';
import { ShowsData } from './shows-data';
export const showsRoutes: Routes = [
  {
    path: '',
    component: Shows,
    children: [],
  },
];
