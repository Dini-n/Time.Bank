import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MemPlusCat } from '../classes/mem-plus-cat';
import { UrlsService } from './urls.service';

@Injectable({
  providedIn: 'root'
})
export class SearchCategoryMemeberService {
  categoryController = "memberCategory/"
  constructor(private http:HttpClient , private urls:UrlsService) { }
  urlApi = this.urls.urlApi;
 
 
 /* getFilterMemberCategory(memPlusCat:MemPlusCat):Observable<Array<MemPlusCat>>
  {
    return this.http.post<Array<MemPlusCat>>(this.urlApi + this.categoryController+"getFilterMemberCategory",memPlusCat);
  }
  */
  
  // getFilterMemberCategory(memPlusCat: MemPlusCat): Observable<Array<MemPlusCat>> {
  //   return this.http.post<Array<MemPlusCat>>(this.urlApi + this.categoryController + "getFilterMemberCategory", memPlusCat);
  // }
  getFilterMemberCategory(memPlusCat: MemPlusCat): Observable<Array<MemPlusCat>> {
    return this.http.post<Array<MemPlusCat>>(this.urlApi + this.categoryController + "getFilterMemberCategory", memPlusCat);
  }
  

  memberCategorySearchResult :Array<MemPlusCat> = new Array<MemPlusCat>();
 
  loadData(memPlusCat:MemPlusCat):boolean
  {   
    this.getFilterMemberCategory(memPlusCat).subscribe(
    
      (myData)=>
     { 
       this.memberCategorySearchResult = myData;      
       return true;  
     },
       (myErr)=>
     { 
        alert(myErr.message);
        return false
      }
    );
    return true 
  }
}


