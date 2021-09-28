import { Component, OnInit } from '@angular/core';
import { CartService } from '../_services/cart.service';
import { CartModelPublic } from '../_models/cart';
import { Cheese } from '../_models/cheese';
//import { CreateCartService } from '../_services/createcart.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  cartData: CartModelPublic;
  cartSize: number;
  cartTotal: number;
  _message: string;
  products: Cheese[];
  msg:string;
  msg1:string;
  store: any = [];
  logo: any;

  constructor(private cartService: CartService) {}

  ngOnInit() {
    // set the products locally
    this.cartService.productData$.subscribe((data) => {
      this.products = data;
    });

    this.cartService.cartDataObs$.subscribe((data) => {
      this.cartData = data;
      this.cartSize = Object.entries(data).reduce(
        (total, val) => total + val[1],
        0
      );
    });
  }

  // Increments the number of items in cart if value is positive,
  // or decrements if negative
  changeItemAmount(id: string, value: number) {
    this.cartService.ModifyProductCount(id, value);
  }

  // returns the details for the specified cheese
  getDetails(id: string): Cheese {
    const details = this.products.filter(
      (product) => product.id === parseInt(id)
    );
    return details[0];
  }

  // calculates the total cart cost
  calculateTotal() {
    return Object.entries(this.cartData).reduce(
      (total, [key, value]) => total + this.getDetails(key).price * value,
      0
    );
  }

  PurchaseCart() {
    console.log('Purchase Cart');
    console.log();
    this.cartService.PurchaseCart(1)
  }

    //recent purchase button
    //open dialog
    openRecentPurchaseDialog() {
      this.msg1='Recent Purchase Button is clicked';
     return this.msg1;  
   //  const dialogRef = this.dialog.open(DialogContentExampleDialog);
   //  dialogRef.afterClosed().subscribe(result => {
   //    console.log(`Dialog result: ${result}`);
   //   });
   }
  
  }
