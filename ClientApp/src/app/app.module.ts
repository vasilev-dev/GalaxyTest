import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RequestsComponent } from './requests/requests.component'
import { SignInComponent} from './sign-in/sign-in.component'
import { AlertsComponent } from './alerts/alerts.component'
import { UserInfoComponent} from './user-info/user-info.component'

import { AlertService } from './alerts/alerts.service'
import { AuthService } from './services/authService'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RequestsComponent,
    SignInComponent,
    AlertsComponent,
    UserInfoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', },
      { path: 'signin', component: SignInComponent, pathMatch: 'full', },
      { path: 'user/info', component: UserInfoComponent, pathMatch: 'full', },
    ])
  ],
  providers: [
    AlertService,
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
