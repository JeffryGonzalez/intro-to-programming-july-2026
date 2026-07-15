import { Component, signal } from '@angular/core';
import { form, FormField, FormRoot, minLength, required } from '@angular/forms/signals';
import { ShowCreate } from '../types';

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
        <label class="label">
          <input type="checkbox" class="checkbox" [formField]="theForm.onNetflix" />
          Netflix
        </label>
        <label class="label">
          <input type="checkbox" class="checkbox" [formField]="theForm.onPrime" />
          Amazon Prime
        </label>
        <label class="label">
          <input type="checkbox" class="checkbox" [formField]="theForm.onHulu" />
          Hulu
        </label>

        <div class="flex flex-col w-full">
          <label for="other">Other</label>
          <input class="input" type="text" [formField]="theForm.otherStreamingService" />
        </div>
      </fieldset>
      <button
        [attr.aria-disabled]="theForm().invalid()"
        type="submit"
        class="btn btn-lg btn-primary"
      >
        Add Show
      </button>
    </form>
  `,
  styles: ``,
})
export class Add {
  model = signal<ShowCreate>({
    title: '',
    description: '',
    otherStreamingService: '',

    onHulu: false,
    onNetflix: false,
    onPrime: false,
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
