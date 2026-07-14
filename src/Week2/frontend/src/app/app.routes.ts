import { Routes } from '@angular/router';
import { Home } from './pages/home';
import { About } from './pages/about';

export const routes: Routes = [
  {
    path: 'home',
    component: Home,
  },
  {
    path: 'about',
    component: About,
  },
  {
    path: 'learning',
    loadChildren: () => import('./features/learning/routes').then((r) => r.learningRoutes),
  },
  {
    path: 'shows',
    loadChildren: () => import('./features/shows/shows-routes').then((r) => r.showsRoutes),
  },
  {
    path: '**',
    redirectTo: 'home',
  },
];
