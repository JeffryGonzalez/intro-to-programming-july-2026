import { httpResource } from '@angular/common/http';
import { computed, Injectable, Service, signal } from '@angular/core';
import { ApiShowItem, StreamingProviders } from './types';

@Service()
export class ShowsData {
  showsResource = httpResource<ApiShowItem[]>(() => '/api/shows');
  #filterBy = signal<StreamingProviders | undefined>(undefined);

  showsList = computed(() => {
    const shows = this.showsResource.value() || [];
    const filtering = this.#filterBy();

    if (filtering === undefined) {
      return shows;
    }
    return shows.filter((s) => s.streamingServices.some((s) => s === filtering));
  });

  setFilterBy(by: StreamingProviders) {
    this.#filterBy.set(by);
  }

  getFilterBy() {
    return this.#filterBy();
  }

  clearFilter() {
    this.#filterBy.set(undefined);
  }
}
