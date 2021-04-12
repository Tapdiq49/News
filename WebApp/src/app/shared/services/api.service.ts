import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAbout } from '../models/about.model';
import { ICategory } from '../models/category.model';
import { IContact } from '../models/contact.model';
import { INews, INewsList } from '../models/news.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getContact():Observable<IContact>{
    return this.http.get<IContact>(`${environment.apiUrl}/v1/contact`);
  }
  public getAbout():Observable<IAbout>{
    return this.http.get<IAbout>(`${environment.apiUrl}/v1/about`);
  }
  public getCategories():Observable<ICategory[]>{
    return this.http.get<ICategory[]>(`${environment.apiUrl}/v1/category`);
  }
  public getNews(count : number):Observable<INewsList>{
    return this.http.get<INewsList>(`${environment.apiUrl}/v1/news?viewCount=${count}`);
  }
  public getCategoryNews(categoryId : number,count : number):Observable<INewsList>{
    return this.http.get<INewsList>(`${environment.apiUrl}/v1/category/${categoryId}/news?viewCount=${count}`);
  }
}
