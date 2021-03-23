package net.fgq.study.pdf.Item;

/**
 * Created by fengguoqiang 2021/3/19
 */
public class TextItemInfo {

    private String jsonKey;
    private ItemKey key;
    private ItemValue value;

    public TextItemInfo(String jsonKey, ItemKey key, ItemValue value) {
        this.jsonKey = jsonKey;
        this.key = key;
        this.value = value;
    }

}
