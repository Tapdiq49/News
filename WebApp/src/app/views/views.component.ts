import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-views',
  template: `<router-outlet></router-outlet>`,
})
export class ViewsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
