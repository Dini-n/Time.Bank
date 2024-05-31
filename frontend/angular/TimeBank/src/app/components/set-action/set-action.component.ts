import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/classes/category';
import { CategoryMember } from 'src/app/classes/category-member';
import { MemPlusCat } from 'src/app/classes/mem-plus-cat';
import { AllCategoriesService } from 'src/app/services/all-categories.service';

@Component({
  selector: 'app-set-action',
  templateUrl: './set-action.component.html',
  styleUrls: ['./set-action.component.css']
})
export class SetActionComponent implements OnInit {


  isChack:boolean=false;
  categories:Array<MemPlusCat> = new Array<MemPlusCat>();

   selectedCat:MemPlusCat  = new MemPlusCat("","","","",false ,new Category("",0,false,0),"",false,0,"",false,0,0);
  constructor(private CategoriesCon:AllCategoriesService,private router:Router) { 
  }
  ngOnInit(): void {
    this.loadData();
  }
  loadData()
  {
 /* let b:Boolean = this.CategoriesCon.loadData()
  if(b){
    this.categories = this.CategoriesCon.categories
    console.log("פעולת השמה")
    console.log(this.categories)
   
  }
  else
  console.log("error") */   
  this.CategoriesCon.getAllMemberCategory().subscribe(
   (myData)=>
   { 
   this.categories = myData;
   console.log("in set action ts");

   console.log(this.categories);
     
     },
     (myErr)=>
     {  alert(myErr.message);}
    );
   
  }
  detiels(cat:MemPlusCat){
    this.isChack=!this.isChack;
    this.selectedCat = cat;
  }


  onFilteredData(filteredData: MemPlusCat[]) {
    // Handle the filtered data here
    console.log("the categoris data before insert categories");
    console.log(this.categories);

    this.categories=filteredData;
    
    console.log("the filster data after we get the categories"+filteredData);
    console.log(filteredData);

    console.log("the categoris data after we get the categorie"+this.categories);
    console.log(this.categories);


  }
  
}

