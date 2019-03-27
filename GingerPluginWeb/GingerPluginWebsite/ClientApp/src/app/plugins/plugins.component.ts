import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'plugins',
  templateUrl: './plugins.component.html'
})
export class PluginsComponent {
    title = 'Plugins';


    onSubmit(searchForm) {
        console.log(searchForm);
    }
}
