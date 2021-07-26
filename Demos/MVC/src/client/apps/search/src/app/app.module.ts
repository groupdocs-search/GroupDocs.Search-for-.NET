import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SearchModule } from "@groupdocs.examples.angular/search";

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule,
    SearchModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
