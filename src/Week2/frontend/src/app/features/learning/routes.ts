import { Routes } from '@angular/router';
import { Learning } from './learning';
import { Home } from './pages/home';
import { SignalsDemo } from './pages/signals-demo';
export const learningRoutes: Routes = [
  {
    path: '',
    component: Learning,
    children: [
      {
        path: '',
        component: Home,
      },
      {
        path: 'signals',
        component: SignalsDemo,
      },
    ],
  },
];
