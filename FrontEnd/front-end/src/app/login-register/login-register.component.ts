import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent {
  loginUsername: string = '';
  loginPassword: string = '';
  registerUsername: string = '';
  registerPassword: string = '';
  registerEmail: string = '';

  constructor(private http: HttpClient, private router: Router) { }

  login() {
    // Prepare the login data
    const loginData = {
      username: this.loginUsername,
      password: this.loginPassword
    };

    // Send the login data to the backend API
    this.http.post('/api/login', loginData).subscribe(
      response => {
        console.log('Login successful!');
        this.router.navigate(['/search']);
      },
      error => {
        console.error('Error logging in:', error);
        
      }
    );
  }

  register() {
    // Prepare the register data
    const registerData = {
      username: this.registerUsername,
      password: this.registerPassword,
      email: this.registerEmail
    };

    // Send the register data to the backend API
    this.http.post('/api/register', registerData).subscribe(
      response => {
        console.log('Registration successful!');
        // Handle the response from the backend
      },
      error => {
        console.error('Error registering:', error);
        // Handle the error from the backend
      }
    );
  }
}
