import { HttpClient, httpResource } from '@angular/common/http';
import { computed, inject, signal } from '@angular/core';
import { ApiShowItem, ProviderFlags, ShowCreate, StreamingProviders } from './types';
import { lastValueFrom } from 'rxjs';

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
    const providerToKeyMap: Record<keyof ProviderFlags, StreamingProviders> = {
      onNetflix: 'netflix',
      onPrime: 'prime',
      onHulu: 'hulu',
      onParamount: 'paramount',
      onAppletv: 'appletv',
      onCrunchyroll: 'crunchyroll',
    };
    const showToAdd: Omit<ApiShowItem, 'id'> = {
      title: show.title,
      description: show.description,
      streamingServices: Object.entries(show.streamingProviders)
        .filter(([key, value]) => key !== 'otherStreamingService' && value === true)
        .map(([key]) => providerToKeyMap[key as keyof ProviderFlags]),
    };
    console.log(showToAdd);
    await lastValueFrom(this.#http.post<ApiShowItem>('/api/shows', showToAdd));
    this.showsResource.reload();
  }

  readonly providersMap: Record<
    StreamingProviders,
    { provider: keyof ProviderFlags; display: string }
  > = {
    crunchyroll: { provider: 'onCrunchyroll', display: 'Crunchyroll Anime' },
    netflix: { provider: 'onNetflix', display: 'Netflix' },
    prime: { provider: 'onPrime', display: 'Amazon Prime' },
    hulu: { provider: 'onHulu', display: 'Hulu' },
    paramount: { provider: 'onParamount', display: 'Paramount+' },
    appletv: { provider: 'onAppletv', display: 'Apple TV+' },
  };
}
