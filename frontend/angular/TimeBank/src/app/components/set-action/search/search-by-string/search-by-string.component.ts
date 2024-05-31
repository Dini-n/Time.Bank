import { Component } from '@angular/core';

@Component({
  selector: 'app-search-by-string',
  templateUrl: './search-by-string.component.html',
  styleUrls: ['./search-by-string.component.scss']
})
export class SearchByStringComponent {
  searchQuery: string ="";

  search() {
    // Perform search logic here
    console.log('Searching for:', this.searchQuery);
  }
}
