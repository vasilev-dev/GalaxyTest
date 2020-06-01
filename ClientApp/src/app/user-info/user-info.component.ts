import { Component, Inject } from "@angular/core";
import { AuthService } from "../services/authService";
import { HttpClient } from "@angular/common/http";

@Component({
    selector: 'sign-in-comp',
    templateUrl: './user-info.component.html',
    styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent {
  public userInfo: UserInfo = null;

  constructor(private authService: AuthService, private http: HttpClient, @Inject("BASE_URL") private baseUrl: string ) {
    let headers = this.authService.jwtHeader;
    this.http.get<UserInfo>(baseUrl + "user/information", { 'headers': this.authService.jwtHeader }).subscribe(response => {
      this.userInfo = response;
    })
  }

  get username() {
    return this.authService.username;
  }

}

interface UserInfo {
  name: string,
  birthday: Date,
  amount: number
}
