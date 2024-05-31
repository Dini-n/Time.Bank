
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/classes/category';
import { MemPlusCat } from 'src/app/classes/mem-plus-cat';
import { FormsModule } from '@angular/forms';
import { SearchCategoryMemeberService } from 'src/app/services/search-category-memeber.service';

@Component({
  selector: 'app-search-by-category',
  templateUrl: './search-by-category.component.html',
  styleUrls: ['./search-by-category.component.scss']
})




export class SearchByCategoryComponent implements OnInit {
  filterOptions: MemPlusCat =new MemPlusCat('', '', '', '', false,new Category("",0,false,0), '', false, 0, '', false, 0, 0);;
  @Output() filteredData: EventEmitter<MemPlusCat[]> = new EventEmitter<MemPlusCat[]>();
  isFilterOpen = false;

  constructor(private CategoriesCon:SearchCategoryMemeberService,private router:Router) {
  }
  ngOnInit(): void {
    // this.isFilterOpen=true;
  }
  

  
  toggleFilter() {
    this.isFilterOpen = !this.isFilterOpen;
  }
  loadData()
  {
  
  this.CategoriesCon.getFilterMemberCategory(this.filterOptions).subscribe(
   (myData)=>
   { 
    const filteredData: MemPlusCat[] = []; // Replace this with the actual filtered data

    // Emit the filtered data to the parent component
    this.filteredData.emit(myData);
   //this.filterOptions = myData;
   console.log("in set action ts");
   console.log(this.filterOptions);
     
     },
     (myErr)=>
     {  alert(myErr.message);}
    );
   
  }

  isFilterContainerOpen = false;


  toggleFilterContainer() {
    this.isFilterContainerOpen = !this.isFilterContainerOpen;
  }

  resetFilters() {
    this.filterOptions.memGiverName = '';
    // Reset other filter options as needed
  }

  applyFilter() {
    // Apply the filter with the selected options
    console.log(this.filterOptions);
    this.loadData();
   
    
    }
 }