import { Component, computed, inject, input } from '@angular/core';
import { CounterData } from '../counter-data';

@Component({
  selector: 'app-learning-fizzbuzz',
  imports: [],
  template: `
    @switch (fizzBuzz()) {
      @case ('FizzBuzz') {
        <p>We have a winner! It is FizzBuzz</p>
      }
      @case ('Fizz') {
        <p>This is fizz. Not bad</p>
      }
      @case ('Buzz') {
        <p>You are buzzing!</p>
      }
      @default {
        <p>Nothing</p>
      }
    }
  `,
  styles: ``,
})
export class FizzBuzz {
  service = inject(CounterData);
  sampleNumber = this.service.count;

  fizzBuzz = computed(() => {
    const current = this.sampleNumber();
    if (current === 0) {
      return;
    }
    if (current % 3 === 0 && current % 5 === 0) {
      return 'FizzBuzz';
    }
    if (current % 3 === 0) {
      return 'Fizz';
    }
    if (current % 5 === 0) {
      return 'Buzz';
    }
    return;
  });
}
