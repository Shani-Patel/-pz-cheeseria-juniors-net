import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private server_url = environment.serverURL;

  constructor(private http: HttpClient) {}

  getCheeses(): Observable<any> {
    return this.http.get(this.server_url + '/cheeses');
  }

  setCart(id: Number): Observable<any> {
    let endpoint = '/v1/dbo/cheese/' + id
    const url123 = this.http.put(this.server_url + endpoint , id);
    console.log(url123)
    return url123
  }
}
