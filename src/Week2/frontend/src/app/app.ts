import { Component, signal } from '@angular/core';
import { Heading } from './navigation/heading';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [Heading, RouterOutlet],
  template: `
    <app-heading />
    <main class="container mx-auto">
      <router-outlet />
    </main>
  `,
  styles: [],
})
export class App {}
