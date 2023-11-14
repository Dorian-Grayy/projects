package com.example.scaner10;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {

    public static final String DB_NAME = "app.db";
    public static String DB_PATH = "";
    public static final int DB_VERSION = 1;
    public static final String TABLE_ORDERS = "orders";

    public SQLiteDatabase mDataBase;
    public final Context mContext;
    public boolean mNeedUpdate = false;

    public static final String KEY_ID = "_id";
    public static final String KEY_NAME = "name";
    public static final String KEY_COST = "cost";
    public static final String KEY_COUNT = "count";

    public DatabaseHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
        if (android.os.Build.VERSION.SDK_INT >= 17)
            DB_PATH = context.getApplicationInfo().dataDir + "/databases/";
        else
            DB_PATH = "/data/data/" + context.getPackageName() + "/databases/";
        this.mContext = context;

        copyDataBase();

        this.getReadableDatabase();
    }

    public void updateDataBase() throws IOException {
        if (mNeedUpdate) {
            File dbFile = new File(DB_PATH + DB_NAME);
            if (dbFile.exists())
                dbFile.delete();

            copyDataBase();

            mNeedUpdate = false;
        }
    }

    private boolean checkDataBase() {
        File dbFile = new File(DB_PATH + DB_NAME);
        return dbFile.exists();
    }

    private void copyDataBase() {
        if (!checkDataBase()) {
            this.getReadableDatabase();
            this.close();
            try {
                copyDBFile();
            } catch (IOException mIOException) {
                throw new Error("ErrorCopyingDataBase");
            }
        }
    }

    private void copyDBFile() throws IOException {
        InputStream mInput = mContext.getAssets().open(DB_NAME);
        OutputStream mOutput = new FileOutputStream(DB_PATH + DB_NAME);
        byte[] mBuffer = new byte[1024];
        int mLength;
        while ((mLength = mInput.read(mBuffer)) > 0)
            mOutput.write(mBuffer, 0, mLength);
        mOutput.flush();
        mOutput.close();
        mInput.close();
    }

    public boolean openDataBase() throws SQLException {
        mDataBase = SQLiteDatabase.openDatabase(DB_PATH + DB_NAME, null, SQLiteDatabase.CREATE_IF_NECESSARY);
        return mDataBase != null;
    }

    @Override
    public synchronized void close() {
        if (mDataBase != null)
            mDataBase.close();
        super.close();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
db.execSQL("create table " + TABLE_ORDERS + "(" + KEY_ID
        + " integer primary key," + KEY_NAME + " text,"
        + KEY_COST + " real," + KEY_COUNT + "real" +")");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        if (newVersion > oldVersion)
            mNeedUpdate = true;
        db.execSQL("drop table if exists " + TABLE_ORDERS);
        onCreate(db);
    }
    void addOrders(ForOrders forOrders) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(KEY_ID, forOrders.GetID());
        values.put(KEY_NAME, forOrders.GetName());
        values.put(KEY_COST, forOrders.GetCost());
        values.put(KEY_COUNT, forOrders.GetCount());

        // Inserting Row
        db.insert(TABLE_ORDERS, null, values);
        db.close(); // Closing database connection
    }

    // Getting single contact
    ForOrders getOrders(int id) {
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.query(TABLE_ORDERS, new String[] { KEY_ID,
                        KEY_NAME, KEY_COST, KEY_COUNT }, KEY_ID + "=?",
                new String[] { String.valueOf(id) }, null, null, null, null);
        if (cursor != null)
            cursor.moveToFirst();

        ForOrders orders = new ForOrders(Integer.parseInt(cursor.getString(0)),
                cursor.getString(1), cursor.getDouble(2), cursor.getDouble(3));
        // return contact
        return orders;
    }

    // Getting All Contacts
    public List<ForOrders> getAllOrders() {
        List<ForOrders> contactList = new ArrayList<ForOrders>();
        // Select All Query
        String selectQuery = "SELECT * FROM " + TABLE_ORDERS;

        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);

        // looping through all rows and adding to list
        if (cursor.moveToFirst()) {
            do {
                ForOrders forOrders = new ForOrders();
                forOrders.SetID(Integer.parseInt(cursor.getString(0)));
                forOrders.SetName(cursor.getString(1));
                forOrders.SetCost(cursor.getDouble(2));
                forOrders.SetCount(cursor.getDouble(3));

                String name = cursor.getString(1) +"\n"+ cursor.getString(2);
                Order.ArrayOfOrder.add(name);
                // Adding contact to list
                contactList.add(forOrders);
            } while (cursor.moveToNext());
        }

        // return contact list
        return contactList;
    }

    // Updating single contact
    public int updateOrders(ForOrders forOrders) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(KEY_ID, forOrders.GetID());
        values.put(KEY_NAME, forOrders.GetName());
        values.put(KEY_COST, forOrders.GetCost());
        values.put(KEY_COUNT, forOrders.GetCount());

        // updating row
        return db.update(TABLE_ORDERS, values, KEY_ID + " = ?",
                new String[] { String.valueOf(forOrders.GetID()) });
    }

    // Deleting single contact
    public void deleteOrders(ForOrders forOrders) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_ORDERS, KEY_ID + " = ?",
                new String[] { String.valueOf(forOrders.GetID()) });
        db.close();
    }

    // Getting contacts Count
    public int getOrdersCount() {
        String countQuery = "SELECT * FROM " + TABLE_ORDERS;
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(countQuery, null);
        cursor.close();

        // return count
        return cursor.getCount();
    }
}
