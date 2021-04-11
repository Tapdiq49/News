import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IContact } from '../models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getContact():Observable<IContact>{
    return this.http.get<IContact>(`${environment.apiUrl}/v1/contact`);
  }
}
