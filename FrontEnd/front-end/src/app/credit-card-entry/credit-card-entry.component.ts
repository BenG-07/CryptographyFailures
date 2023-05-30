import { environment } from '../../environments/environment';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AES, enc } from 'crypto-js';


@Component({
  selector: 'app-credit-card-entry',
  templateUrl: './credit-card-entry.component.html',
  styleUrls: ['./credit-card-entry.component.css']
})
export class CreditCardEntryComponent {
  creditCardNumber: string = '165498489463546';

  constructor(private http: HttpClient) { }

  submitCreditCard() {
    // Encrypt the credit card number before sending it to the backend
    const encryptedCreditCard = AES.encrypt(this.creditCardNumber, environment.encryptionKey).toString();

    // Send the encrypted credit card number to the backend API
    this.http.post('/api/credit-cards', { creditCard: encryptedCreditCard }).subscribe(
      response => {
        console.log('Credit card submitted successfully!');
      },
      error => {
        console.error('Error submitting credit card:', error);
      }
    );
  }
}
