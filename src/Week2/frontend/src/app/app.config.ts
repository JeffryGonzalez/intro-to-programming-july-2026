import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import {
  provideRouter,
  withExperimentalAutoCleanupInjectors,
  withViewTransitions,
} from '@angular/router';

import { routes } from './app.routes';


export const appConfig: ApplicationConfig = {
  providers: [
    // anyone in the entire application can inject this. no @Service needed.
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes, withExperimentalAutoCleanupInjectors()),
  ],
};
