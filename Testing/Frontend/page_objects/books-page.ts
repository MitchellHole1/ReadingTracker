import { Page } from "@playwright/test";

exports.BooksPage = class BooksPage {

    page: Page;

    table_headers = ['Name', 'Author Name', 'Year Published', 'Original Language', 'Page Count', 'Genres',];

    constructor(page) {
        this.page = page;
    }
}