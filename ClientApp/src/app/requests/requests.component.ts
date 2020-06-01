import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AlertService } from "../alerts/alerts.service"
import { AuthService } from "../services/authService";
import { Router } from '@angular/router';

@Component({
    selector: 'requests-comp',
    templateUrl: './requests.component.html',
    styleUrls: ['./requests.component.css']
})
export class RequestsComponent {
  constructor(private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string,
    private alertService: AlertService,
    private authService: AuthService,
    private router: Router) {

  }

  public clientErrorSubmit() {
    this.http.get(this.baseUrl + "error").subscribe(response => {
      console.log(response);
    }, error => {
      this.alertService.addAlert(error.error);
      console.log(error);
    });
  }

  public exceptionSubmit() {
    this.http.get(this.baseUrl + "exception").subscribe(response => {
    }, error => {
      console.log(error);
      this.alertService.addAlert("Server error!")
    });
  }

  public userInformationSubmit() {
    if(this.authorized) {
      this.router.navigate(['user/info']);
    } else {
      this.alertService.addAlert("Unauthorized")
    }
  }

  get authorized() {
    return this.authService.authorized;
  }
}
