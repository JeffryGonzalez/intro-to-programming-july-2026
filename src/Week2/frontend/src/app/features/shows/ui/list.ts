import { TitleCasePipe } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { ShowsData } from '../shows-data';
import { Filter } from './filter';

@Component({
  selector: 'app-shows-list',
  imports: [TitleCasePipe, Filter],
  providers: [],
  template: `
    @if (dataService.showsResource.error()) {
      <div class="alert alert-error">
        <p>Sorry - that didn't work. Try again later?</p>
        <button class="btn btn-primary" (click)="dataService.showsResource.reload()">Reload</button>
      </div>
    }
    @if (dataService.showsResource.isLoading()) {
      <div class="alert alert-info">Chill out - loading your data.</div>
    } @else {
      <app-shows-filter />
      <div class="grid grid-cols-4 gap-4">
        @for (show of dataService.showsList(); track show.id) {
          <div class="card w-96 bg-base-100 card-lg shadow-sm">
            <div class="card-body border-2 border-amber-50">
              <h2 class="card-title">{{ show.title }}</h2>
              <p>
                {{ show.description }}
              </p>
              <ul class="flex flex-row gap-2">
                @for (svc of show.streamingServices; track $index) {
                  <li class="badge badge-accent">{{ svc | titlecase }}</li>
                }
              </ul>
              <div class="justify-end card-actions">
                <button class="btn btn-primary">Add To Favorites</button>
              </div>
            </div>
          </div>
        } @empty {
          <div class="alert alert-warning">
            <span>No shows found. </span>
          </div>
        }
      </div>
    }
  `,
  styles: ``,
})
export class List {
  dataService = inject(ShowsData);
}
