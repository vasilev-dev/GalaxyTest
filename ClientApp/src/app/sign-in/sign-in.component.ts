import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormBuilder } from "@angular/forms";
import { Router } from '@angular/router';
import { AuthService } from '../services/authService'

@Component({
    selector: 'sign-in-comp',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {
  public errors: string[];
  public signInForm: FormGroup

  constructor(private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string,
    private formBuilder : FormBuilder,
    private router: Router,
    private authService: AuthService) {
      this.signInForm = this.formBuilder.group({
        username: '',
        password: ''
      })
  }

  public onSubmit(signInFormValue) {
    this.http.post<any>(this.baseUrl + "login", signInFormValue).subscribe(response => {
      this.authService.jwtToken = response.token;
      this.authService.username = response.username;
      this.router.navigate(['']);
    }, response => {
      console.log(response);
      this.errors = response.error.errors;
    });
  }


  get username() {
    return this.signInForm.get('username')
  }

  get password() {
    return this.signInForm.get('password')
  }
}
