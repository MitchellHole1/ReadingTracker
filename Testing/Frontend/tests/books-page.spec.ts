import { test, expect } from './helpers';

const { BooksPage } = require('../page_objects/books-page')

test.describe('Books Page Tests', () => {

  let booksPage;


  test.beforeEach(async ({ page }) => {
    booksPage = new BooksPage(page);

    await page.goto('/');
    await page.getByRole('link', { name: 'Books' }).click();
  });

  test('Should land on the books page', async ({ page }) => {
    await expect(page).toHaveTitle(/Books/);
  });

  test('Should display a list of books', async ({ page }) => {
    booksPage.table_headers.forEach(async (header) => {
      await expect(page.getByText(header, { exact: true })).toBeVisible();
    });
    await expect(page.locator('text=The Hobbit')).toBeVisible();
    await expect(page.locator('text=The Road')).toBeVisible();
  });

  test('Should open a create book model when Add Book button is clicked', async ({ page }) => {
    await booksPage.ClickAddBookButton();
    await expect(page.getByRole('dialog').getByText('Add Book')).toBeVisible();
  });

  test('Should close the create book model when the close button is clicked', async ({ page }) => {
    await booksPage.ClickAddBookButton();
    await page.getByRole('button', { name: 'Close' }).click();
    await expect(page.getByRole('dialog').getByText('Add Book')).not.toBeVisible();
  });

  const browserBookNames = {
    'chromium': 'Beren and Luthien',
    'firefox': 'The Children of Hurin',
    'webkit': 'The Silmarillion'
  }

  test('Should create a book when valid input is provided', async ({ page, browserName }) => {
    await booksPage.ClickAddBookButton();
    await page.getByRole('textbox', { name: 'Name' }).fill(browserBookNames[browserName]);
    await page.getByRole('textbox', { name: 'AuthorId' }).fill('2');
    await page.getByRole('spinbutton', { name: 'YearPublished' }).fill('1977');
    await page.getByRole('textbox', { name: 'OriginalLanguage' }).fill('English');
    await page.locator('#formBasicType').selectOption({ label: 'Novel' });
    await page.locator('#formBasicGenre').selectOption([{ label: 'Fantasy' }, { label: 'Romance' }]);
    await page.getByRole('spinbutton', { name: 'Page Count' }).fill('500');
    await page.getByRole('button', { name: 'Submit' }).click();
    await expect(page.getByRole('dialog').getByText('Add Book')).not.toBeVisible();
    await expect(page.getByText(browserBookNames[browserName])).toBeVisible();
  });

});