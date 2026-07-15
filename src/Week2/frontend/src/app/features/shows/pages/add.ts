import { Component } from '@angular/core';
import { ApiShowItem } from '../types';

type ShowCreate = Pick<ApiShowItem, 'title' | 'description'> & {
  otherStreamingService: string;
};
@Component({
  selector: 'app-shows-add',
  imports: [],
  template: ` <p>Add A Show Here</p> `,
  styles: ``,
})
export class Add {
  model: ShowCreate = {
    title: '',
    description: '',
    otherStreamingService: '',
  };
}
