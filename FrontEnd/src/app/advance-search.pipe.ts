import { Pipe, PipeTransform } from '@angular/core';
import { Patient, SearchModel} from './patients';

@Pipe({
  name: 'advanceSearch',
  pure: false
})
export class AdvanceSearchPipe implements PipeTransform {

  transform(posts: Patient[], search: SearchModel): any {
     console.log(search, 'd');
    // no post return
    if(!posts || posts.length === 0) return posts;
    console.table(posts);

    // search is blank, return post
    if(!search || !search.patientId && !search.patientName && !search.email) return posts;
debugger;
  console.log(search);
    return posts.filter((post) => {
      return (!search.patientId || post.patientId === Number(search.patientId) ) &&
          (!search.patientName || post.patientName.startsWith(search.patientName))  &&
          (!search.email || post.email.includes(search.email));
    })
    
  }

}