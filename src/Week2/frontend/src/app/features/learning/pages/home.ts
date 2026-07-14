import { Component } from '@angular/core';
import { FizzBuzz } from './fizz-buzz';

@Component({
  selector: 'app-learning-home',
  imports: [FizzBuzz],
  template: `
    <p>All of our learning stuff will go here</p>
    <app-learning-fizzbuzz />
  `,
  styles: ``,
})
export class Home {}
