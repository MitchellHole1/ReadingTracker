import { test, expect } from '@playwright/test';

test.describe('Books Page Tests', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
    await page.getByRole('link', { name: 'Books' }).click();
  });

  test('Should land on the books page', async ({ page }) => {
    await expect(page).toHaveTitle(/Books/);
  });

});