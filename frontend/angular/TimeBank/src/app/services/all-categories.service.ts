import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../classes/category';
import { CategoryMember } from '../classes/category-member';
import { MemPlusCat } from '../classes/mem-plus-cat';
import { UrlsService } from './urls.service';

@Injectable({
  providedIn: 'root'
})
export class AllCategoriesService {
  categoryController = "memberCategory/"
  constructor(private http:HttpClient , private urls:UrlsService) { }
  urlApi = this.urls.urlApi;

 
  getAllMemberCategory():Observable<Array<MemPlusCat>>
  {
    return this.http.get<Array<MemPlusCat>>(this.urlApi + this.categoryController+"getAllMemberCategory");
  }
  categories:Array<MemPlusCat>= new Array<MemPlusCat>();
  
  loadData():boolean
  {   
    this.getAllMemberCategory().subscribe(
    
      (myData)=>
     { 
       this.categories = myData;      
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
