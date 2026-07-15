import { Component, signal } from '@angular/core';
import { form, FormField, FormRoot, minLength, required } from '@angular/forms/signals';
import { ProviderFlags, providers, ShowCreate, StreamingProviders } from '../types';

@Component({
  selector: 'app-shows-add',
  imports: [FormField, FormRoot],
  template: `
    <form class="flex flex-col gap-4 max-w-lg" [formRoot]="theForm">
      <div class="flex flex-col w-full">
        <label for="title">Title</label>
        <input class="input" type="text" [formField]="theForm.title" />
        <div>
          @let titleField = theForm.title();
          @if (titleField.touched() && titleField.invalid()) {
            @for (error of titleField.errorSummary(); track error.kind) {
              <span class="label text-error text-xs">{{ error.message }}</span>
            }
          }
        </div>
      </div>
      <div class="flex flex-col w-full">
        <label for="description">Description</label>
        <textarea class="input" type="text" [formField]="theForm.description"></textarea>
      </div>
      <fieldset class="fieldset">
        <legend class="fieldset-legend">Streaming Services</legend>

        @for (p of streamingProvidersList; track p) {
          <div class="flex flex-col w-full">
            <label class="label">
              <input
                [formField]="theForm[providersMap[p].provider]"
                type="checkbox"
                class="checkbox"
              />
              {{ providersMap[p].display }}
            </label>
          </div>
        }

        <div class="flex flex-col w-full">
          <label for="other">Other</label>
          <input class="input" type="text" [formField]="theForm.otherStreamingService" />
        </div>
      </fieldset>
      <button [attr.aria-disabled]="theForm().invalid()" type="submit" class="btn btn-primary">
        Add Show
      </button>
    </form>
  `,
  styles: ``,
})
export class Add {
  protected readonly streamingProvidersList = providers;

  protected readonly providersMap: Record<
    StreamingProviders,
    { provider: keyof ProviderFlags; display: string }
  > = {
    netflix: { provider: 'onNetflix', display: 'Netflix' },
    prime: { provider: 'onPrime', display: 'Amazon Prime' },
    hulu: { provider: 'onHulu', display: 'Hulu' },
    paramount: { provider: 'onParamount', display: 'Paramount+' },
    appletv: { provider: 'onAppletv', display: 'Apple TV+' },
  };

  model = signal<ShowCreate>({
    title: '',
    description: '',
    otherStreamingService: '',

    onHulu: false,
    onNetflix: false,
    onPrime: false,
    onParamount: false,
    onAppletv: false,
  });

  theForm = form(
    this.model,
    (schema) => {
      required(schema.title, { message: 'Ya gotta give us a title!' });
      minLength(schema.title, 5, { message: 'Has to be at least 5 letters' });
      required(schema.description, {
        message: 'Provide a brief description of why you like this show',
      });
    },
    {
      submission: {
        action: async (value) => {
          console.log(this.model());
        },
        onInvalid: (f) => {
          console.log(f());
          f().markAsTouched();
        },
      },
    },
  );
}
