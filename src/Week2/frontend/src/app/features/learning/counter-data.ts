import { Service, signal } from '@angular/core';

@Service()
export class CounterData {
  count = signal(0);
}
