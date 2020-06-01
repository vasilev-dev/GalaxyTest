import { Injectable } from "@angular/core";
import { HttpHeaders } from "@angular/common/http";

@Injectable({ providedIn: 'root' })
export class AuthService {
  get authorized() {
    return localStorage.getItem('auth_token') !== null;
  }

  get username() {
    return localStorage.getItem('username');
  }

  set username(username: string) {
    localStorage.setItem('username', username);
  }

  get jwtHeader() {
    const headers = new HttpHeaders()
    .set('Accept', 'application/json')
    .set('Authorization', "Bearer " + localStorage.getItem('auth_token'))
    return headers;
  }

  set jwtToken(token: string) {
    localStorage.setItem('auth_token', token);
  }

  public resetJwtToken() {
    localStorage.removeItem('auth_token');
  }
}
