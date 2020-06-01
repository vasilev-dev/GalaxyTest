import { Component } from '@angular/core';
import { AuthService } from '../services/authService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authService: AuthService, private router: Router) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public signOut() {
    this.authService.resetJwtToken();
    this.router.navigate(['']);
  }

  get username() {
    return this.authService.username;
  }

  get authorized() {
    return this.authService.authorized;
  }
}
