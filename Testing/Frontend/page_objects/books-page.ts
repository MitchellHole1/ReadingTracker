import { Page } from "@playwright/test";
import { IPageObject } from './page-object';



exports.BooksPage = class BooksPage implements IPageObject {

    page: Page;
    url = '/books';

    table_headers = ['Name', 'Author Name', 'Year Published', 'Original Language', 'Page Count', 'Genres',];

    constructor(page) {
        this.page = page;
    }

    ClickAddBookButton = async () => {
        await this.page.getByRole('button', { name: 'Add Book' }).click();
    }
}