import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  searchText: string = "";
  constructor(private route: ActivatedRoute, private router: Router) {

   }

  ngOnInit(): void {
  }
  public search():void{
    if(this.searchText!= ""){
      this.router.navigate(['news/search/'+ this.searchText], { relativeTo: this.route });
    }
  }
}
