import { Routes } from '@angular/router';
import { Shows } from './shows';
import { ShowsData } from './shows-data';
import { Home } from './pages/home';
import { Add } from './pages/add';
export const showsRoutes: Routes = [
  {
    path: '',
    component: Shows,
    providers: [ShowsData], // when any of my babies need this, create a new instance - and share it with them.
    children: [
      {
        path: '',
        component: Home,
      },
      {
        path: 'add',
        component: Add,
      },
    ],
  },
];
