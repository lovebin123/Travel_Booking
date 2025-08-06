import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './common/interceptor/auth-interceptor.interceptor';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { PageNotFound } from './common/components/page-not-found/page-not-found';

@NgModule({
  declarations: [
    App,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide:JWT_OPTIONS,
      useValue:JWT_OPTIONS
    },
    JwtHelperService
  ],
  bootstrap: [App]
})
export class AppModule { }
