import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import {
  provideRouter,
  withExperimentalAutoCleanupInjectors,
  withViewTransitions,
} from '@angular/router';

import { routes } from './app.routes';
import { ShowsData } from './features/shows/shows-data';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes, withExperimentalAutoCleanupInjectors()),
  ],
};
