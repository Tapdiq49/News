import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsItemComponent } from './news-item.component';

const routes: Routes = [
  { path: '', pathMatch:'full', component:NewsItemComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewsItemRoutingModule { }
