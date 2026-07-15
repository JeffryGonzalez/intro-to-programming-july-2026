import { HttpClient, httpResource } from '@angular/common/http';
import { computed, DOCUMENT, inject, Injectable, Service, signal } from '@angular/core';
import { ApiShowItem, ProviderFlags, ShowCreate, StreamingProviders } from './types';

// @Service() // (old school was @Injectable(...)) You can provide this whenever. Create it when it first used,
// and then pass this sucker around to everything that needs like a cheap bottle of wine around a campfire.
// Jeff hates. this. for reasons. but you do you.
export class ShowsData {
  showsResource = httpResource<ApiShowItem[]>(() => '/api/shows');
  #filterBy = signal<StreamingProviders | undefined>(undefined);
  #http = inject(HttpClient);

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
  async addShow(show: ShowCreate) {
    const showToAdd: Omit<ApiShowItem, 'id'> = {
      title: show.title,
      description: show.description,
      streamingServices: Object.entries(show.streamingProviders)
        .filter(([key, value]) => key !== 'title' && key !== 'description' && value === true)
        .map(
          ([key]) => this.providersMap[key as StreamingProviders].provider as StreamingProviders,
        ),
    };
    console.log('Adding show:', showToAdd);
    //await this.#http.post('/api/shows', showToAdd);
    this.showsResource.reload();
  }

  providersMap: Record<StreamingProviders, { provider: keyof ProviderFlags; display: string }> = {
    netflix: { provider: 'onNetflix', display: 'Netflix' },
    prime: { provider: 'onPrime', display: 'Amazon Prime' },
    hulu: { provider: 'onHulu', display: 'Hulu' },
    paramount: { provider: 'onParamount', display: 'Paramount+' },
    appletv: { provider: 'onAppletv', display: 'Apple TV+' },
  };
}
