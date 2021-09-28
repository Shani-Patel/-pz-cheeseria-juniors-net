import { Injectable } from '@angular/core';
import { ProductsService } from './cheeses.service';
import { CartModelPublic } from '../_models/cart';
import { Cheese } from '../_models/cheese';
import { BehaviorSubject } from 'rxjs'
import { PurchaseModelPublic } from '../_models/purchase'
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class CartService {
  //Data variable to store the cart information on the client's local storage
  private cartDataClient: CartModelPublic = {};
  private purchaseDataClient: PurchaseModelPublic={};
  private server_url = environment.serverURL;
  //private http = HttpClient;

  /*OBSERVABLES FOR THE COMPONENT TO SUBSCRIBE */
  cartTotals$ = new BehaviorSubject<number>(0);
  cartDataObs$ = new BehaviorSubject<CartModelPublic>(this.cartDataClient);
  productData$ = new BehaviorSubject<Cheese[]>([]);

  constructor(private productsService: ProductsService, private http: HttpClient) {
    //fetch cheeses
    this.productsService.getCheeses().subscribe((prods) => {
      this.productData$.next(prods);
    });
  }

  AddProductToCart(id: Number) {
    // if not in cart
    const stringID = id.toString();
    if (this.cartDataClient[stringID] === undefined) {
      // add to cart
      this.cartDataClient[stringID] = 1;
    } else {
      this.cartDataClient[stringID]++;
    }
    this.cartDataObs$.next(this.cartDataClient);
    // console.log(this.cartDataClient);
  }


  // Cart API Call
  setCart(): Observable<any> {
    return this.http.post(this.server_url + '/cheeses/');
  }

  //on Purchase button click
  PurchaseCart(id: Number) {
    // if not in cart
    const stringID = id.toString();
    if (this.cartDataClient[stringID] === undefined) 
    {
      // add to cart
      this.cartDataClient[stringID] = 1;
 
      
      //   constructor(private http: HttpClient) {}
      
      //   getCheeses(): Observable<any> {
      //     return this.http.get(this.server_url + '/cheeses');
      //   }
      

    } 
    else 
    {
      this.cartDataClient[stringID]++;
    }
    this.cartDataObs$.next(this.cartDataClient);
    // console.log(this.cartDataClient);
  }

  // For incrementing and decrementing items in the cart
  // if count is positive, increment, otherwise decrement
  ModifyProductCount(id: string, count: number) {
    if (count > 0) {
      this.cartDataClient[id]++;
      this.cartDataObs$.next(this.cartDataClient);
      return;
    }

    // subtract one
    if (this.cartDataClient[id] > 1) {
      this.cartDataClient[id]--;
      this.cartDataObs$.next(this.cartDataClient);
      return;
    }

    delete this.cartDataClient[id];
    this.cartDataObs$.next(this.cartDataClient);
  }
}
