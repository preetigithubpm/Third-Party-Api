import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  transform(items: any[], filter: any): any {
    if (!items || !filter) {
      return items;
    }

    return items.filter((item) => {
      for (let key in filter) {
        if (item[key] !== filter[key]) {
          return false;
        }
      }
      return true;
    });
  }
}
