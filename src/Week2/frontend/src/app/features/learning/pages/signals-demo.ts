import { Component, computed, inject, signal } from '@angular/core';
import { FizzBuzz } from './fizz-buzz';
import { CounterData } from '../counter-data';

@Component({
  selector: 'app-learning-signals',

  providers: [],
  template: `
    <div>
      <button (click)="decrement()" class="btn btn-circle btn-error">-</button>
      <span class="p-8"
        ><span>{{ service.count() }}</span
        ><span class="pl-4"> {{ isEven() }}</span>
      </span>
      <button (click)="increment()" class="btn btn-circle btn-success">+</button>
    </div>
    <div>
      <button [disabled]="service.count() === 0" (click)="reset()" class="btn btn-primary">
        Reset
      </button>
    </div>
  `,
  styles: ``,
})
export class SignalsDemo {
  // "newish" Angular "rule" - inside a component, if you need state (data), use a Signal.
  // if you *must* you can use an rxjs Observable, but get a note from your mom first.

  // don't do this - this is bad, but I wanna demo

  service = inject(CounterData);

  isEven = computed(() => {
    const current = this.service.count();
    if (current === 0) return false;
    return current % 2 === 0;
  });
  decrement() {
    // this.count.set(this.count() - 1);
    this.service.count.update((current) => current - 1);
    // check to see if any data changed, if it did, update the dom
  }

  increment() {
    this.service.count.update((c) => c + 1);
    // check to see if the data changed, if it did, update the dom
  }

  reset() {
    this.service.count.set(0);
  }
}
