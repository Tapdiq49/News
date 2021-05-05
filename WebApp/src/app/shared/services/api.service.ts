import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAbout } from '../models/about.model';
import { ICategory } from '../models/category.model';
import { IContact } from '../models/contact.model';
import { INews, INewsList } from '../models/news.model';
import { INewsItem } from '../models/newsItem.model';



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
    return this.http.get<INewsList>(`${environment.apiUrl}/v1/news?viewCount=${count}`, {withCredentials: true});
  }
  public getCategoryNews(categoryId : number,count : number):Observable<INewsList>{
    return this.http.get<INewsList>(`${environment.apiUrl}/v1/category/${categoryId}/news?viewCount=${count}`, {withCredentials: true});
  }
  public getNewsById(newsId : number):Observable<INewsItem>{
    return this.http.get<INewsItem>(`${environment.apiUrl}/v1/news/${newsId}`);
  }

  public getLastNews(count : number):Observable<INewsItem[]>{
    return this.http.get<INewsItem[]>(`${environment.apiUrl}/v1/news/lastnews?count=${count}`);
  }

  public newsLike(newsId: number, data:any): Observable<INewsItem> {
    return this.http.post<any>(`${environment.apiUrl}/v1/news/${newsId}/like`, data, {withCredentials: true});
  }

  public newsDislike(newsId: number, data:any): Observable<INewsItem> {
    return this.http.post<any>(`${environment.apiUrl}/v1/news/${newsId}/dislike`, data, {withCredentials: true});
  }

  public getSliderNews():Observable<INewsItem[]>{
    return this.http.get<INewsItem[]>(`${environment.apiUrl}/v1/news/slider`);
  }
  public search(search:string,count : number):Observable<INewsList>{
    return this.http.get<INewsList>(`${environment.apiUrl}/v1/news/search?search=${search}&viewCount=${count}`, {withCredentials: true});
  }
}
