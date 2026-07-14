import { Routes } from '@angular/router';
import { Learning } from './learning';
import { Home } from './pages/home';
import { SignalsDemo } from './pages/signals-demo';
import { CounterData } from './counter-data';
export const learningRoutes: Routes = [
  {
    path: '',
    component: Learning,
    providers: [CounterData],
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
